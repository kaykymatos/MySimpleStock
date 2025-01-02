import { Toaster } from "react-hot-toast";
import { Outlet } from "react-router-dom";
import Layout from "./components/Layout";

function App() {
  return (
    <>
      <Toaster position="top-right" />
      <Layout>
        <Outlet />
      </Layout>
    </>
  );
}

export default App;
