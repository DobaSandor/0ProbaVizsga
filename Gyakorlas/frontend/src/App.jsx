import './App.css'
import {Routes, Route} from 'react-router'
import Home from './pages/Home'
import Hos from './pages/Hos'
import UjHos from './pages/UjHos'



function App() {
  return (
    <>
      <nav className='flex justify-center items-center gap-6 text-2xl rounded-2xl bg-blue-800 p-2'>
        <a href="/">Home</a>
        <a href="/hos">Hős</a>
        <a href="/ujhos">Új hős</a>
      </nav>
      <Routes>
        <Route path="/" element={<Home></Home>} />
        <Route path="/hos" element={<Hos></Hos>} />
        <Route path="/ujhos" element={<UjHos></UjHos>} />
      </Routes>
    </>
  )
}

export default App
