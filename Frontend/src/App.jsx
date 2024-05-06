import {Routes, Route, Link, useNavigate} from "react-router-dom"
import HomePage from "./pages/HomePage";
import CreatePage from "./pages/CreatePage";
import EditPage from "./pages/EditPage";
import RegisterPage  from "./pages/RegistePage";
import LoginPage from "./pages/LoginPage";


import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';


export const VITE_BACKEND_URL = import.meta.env.VITE_VITE_BACKEND_URL;

const App = () => {
  const navigate = useNavigate();
  const Logout = () => {
    sessionStorage.clear();
    navigate("/login");
  }

  return (
    <div>
      <nav className="bg-gray-800">
        <div className="container mx-auto p-2 grid">
          <Link to="/"><h2 className="text-white text-2xl font-bold">Crud Produtos</h2></Link>
          <div className="flex justify-between items-center ">
            {sessionStorage.getItem("token") && (
              <button onClick={Logout} className=" absolute top-0 right-0 h-11 w-15 bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded text-sm">
                Logout
              </button>
            )}
          </div>
          
        </div>
        <div>
          
        </div>
      </nav> 
      <div className="container mx-auto p-2 h-full">     
        <Routes>
          <Route index element={<HomePage/>}></Route>
          <Route path="/create" element={<CreatePage/>}></Route>
          <Route path="/register" element={<RegisterPage/>}></Route>
          <Route path="/login" element={<LoginPage/>}></Route>
          <Route path="/edit/:id" element={<EditPage/>}></Route>
        </Routes>
      </div>
      <ToastContainer/>

    </div>
  );
}

export default App;