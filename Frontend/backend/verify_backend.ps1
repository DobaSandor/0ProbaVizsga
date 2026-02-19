$baseUrl = "http://localhost:6969"

Write-Host "Verifying Heroes Backend..."

# 1. GET /api/kasztok
try {
    $kasztok = Invoke-RestMethod -Uri "$baseUrl/api/kasztok" -Method Get
    Write-Host "GET /api/kasztok: Success. Count: $($kasztok.Count)"
    if ($kasztok.Count -ne 6) { Write-Error "Expected 6 classes, got $($kasztok.Count)" }
} catch {
    Write-Error "GET /api/kasztok failed: $_"
}

# 2. GET /api/hosok (Initial)
try {
    $hosok = Invoke-RestMethod -Uri "$baseUrl/api/hosok" -Method Get
    Write-Host "GET /api/hosok (Initial): Success. Count: $($hosok.Count)"
    if ($hosok.Count -lt 1) { Write-Error "Expected at least 1 hero." }
} catch {
    Write-Error "GET /api/hosok failed: $_"
}

# 3. POST /api/hosok (Valid)
$newHero = @{
    nev = "Elara Fényszövő"
    szarmazas = "Ezüst-erdő"
    szint = 15
    kasztId = 2
}
try {
    $response = Invoke-RestMethod -Uri "$baseUrl/api/hosok" -Method Post -Body ($newHero | ConvertTo-Json) -ContentType "application/json"
    Write-Host "POST /api/hosok (Valid): Success."
    # Check response message if possible, though Invoke-RestMethod might just return the object or null depending on status code.
    # The controller returns { message = "..." }
    if ($response.message -eq "Sikeresen hozzáadva") {
        Write-Host "  Message verified."
    } else {
        Write-Warning "  Unexpected message: $($response.message)"
    }
} catch {
    Write-Error "POST /api/hosok (Valid) failed: $_"
}

# 4. POST /api/hosok (Invalid - Missing KasztId)
$invalidHero = @{
    nev = "Invalid Hero"
    szarmazas = "Nowhere"
    szint = 1
    # kasztId intentionally missing (defaults to 0)
}
try {
    Invoke-RestMethod -Uri "$baseUrl/api/hosok" -Method Post -Body ($invalidHero | ConvertTo-Json) -ContentType "application/json"
    Write-Error "POST /api/hosok (Invalid) should have failed but succeeded."
} catch {
    if ($_.Exception.Response.StatusCode -eq [System.Net.HttpStatusCode]::BadRequest) {
        Write-Host "POST /api/hosok (Invalid): Success (Correctly returned 400 Bad Request)."
    } else {
        Write-Error "POST /api/hosok (Invalid) failed with unexpected status: $($_.Exception.Response.StatusCode)"
    }
}

# 5. GET /api/hosok (After Insert)
try {
    $hosok = Invoke-RestMethod -Uri "$baseUrl/api/hosok" -Method Get
    Write-Host "GET /api/hosok (Final): Success. Count: $($hosok.Count)"
} catch {
    Write-Error "GET /api/hosok failed: $_"
}
