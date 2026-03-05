import React from 'react'
import { useEffect } from 'react'

const Hos = () => {
  const [hosok, setHosok] = React.useState([])
  const [kasztok, setKasztok] = React.useState([])

  useEffect (() => {
    getData(), getKasztok()
  }, [])

  const getData = async () => {
    const response = await fetch("http://localhost:3080/api/hosok")
    const data = await response.json()
    console.log(data)
    setHosok(data)
  }

  const getKasztok = async () => {
    const response = await fetch("http://localhost:3080/api/kasztok")
    const data = await response.json()
    console.log(data)
    setKasztok(data)
  }

  // 0: {id: 1, nev: 'Harcos'}

  return (
    <div>
      <h1 className='text-3xl font-bold mb-6 mt-5'>Hősök</h1>

      {/* hosok.map */}
      <div>
        {hosok.map(hos => (
          <div key={hos.id} className='border-2 border-blue-900 p-4 rounded-lg mb-4 bg-blue-800'>
            <h2 className='text-xl font-bold'>{hos.nev}</h2>
            <p><strong>Szarmazas:</strong> {hos.szarmazas}</p>
            <p><strong>Szint:</strong> {hos.szint}</p>
            <p><strong>Kaszt ID:</strong> {hos.kasztId}</p>
            <p><strong>Kaszt neve:</strong> {kasztok.find(k => k.id === hos.kasztId)?.nev || 'N/A'}</p>
          </div>
        ))}
      </div>
        <h1 className='text-3xl font-bold mb-6 mt-2'>Kasztok</h1>
      <div>
        {kasztok.map(kaszt => (
          <div key={kaszt.id} className='border-2 border-green-900 p-4 rounded-lg mb-4 bg-green-800'>
            <h2 className='text-xl font-bold'>{kaszt.nev}</h2>
          </div>
        ))  
        }
      </div>
    </div>
  )
}

export default Hos
