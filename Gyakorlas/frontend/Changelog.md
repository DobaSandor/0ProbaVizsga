npm i 
npm npm create vite@latest
npm install tailwindcss @tailwindcss/vite

vite.config.ts
```
import { defineConfig } from 'vite'
import tailwindcss from '@tailwindcss/vite'

export default defineConfig({
  plugins: [
    tailwindcss(),
  ],
})
```

CSS
```
@import "tailwindcss";
```

npm i react-router

```
import React from "react";
import ReactDOM from "react-dom/client";
import { BrowserRouter } from "react-router";
import App from "./app";

const root = document.getElementById("root");

ReactDOM.createRoot(root).render(
  <BrowserRouter>
    <App />
  </BrowserRouter>,
);
```

backend-be cors
(npm i cors)

