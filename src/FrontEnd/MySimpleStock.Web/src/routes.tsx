import { createBrowserRouter } from "react-router-dom";
import App from "./App";
import Dashboard from "./pages/Dashboard";
import Login from "./pages/Login";
import * as ClientsPages from "./pages/clients";
import * as ProductsPages from "./pages/products";
import * as ReportPages from "./pages/reports";
import * as SalesPages from "./pages/sales";

export const routes = createBrowserRouter([
  {
    element: <App />,
    children: [
      {
        path: "/",
        element: <Dashboard />,
      },

      {
        path: "/clients",
        element: <ClientsPages.ClientList />,
      },
      {
        path: "/clients/create",
        element: <ClientsPages.ClientCreate />,
      },
      {
        path: "/clients/edit/:id",
        element: <ClientsPages.ClientEdit />,
      },
      {
        path: "/clients/delete/:id",
        element: <ClientsPages.ClientDelete />,
      },

      {
        path: "/products",
        element: <ProductsPages.ProductList />,
      },
      {
        path: "/products/create",
        element: <ProductsPages.ProductCreate />,
      },
      {
        path: "/products/edit/:id",
        element: <ProductsPages.ProductEdit />,
      },
      {
        path: "/products/delete/:id",
        element: <ProductsPages.ProductDelete />,
      },


      {
        path: "/reports",
        element: <ReportPages.Reports />,
      },

      {
        path: "/sales",
        element: <SalesPages.SaleList />,
      },
      {
        path: "/sales/create",
        element: <SalesPages.SaleCreate />,
      },
      {
        path: "/sales/delete/:id",
        element: <SalesPages.SaleDelete />,
      },

      {
        path: "/login",
        element: <Login />,
      },
    ],
  },
]);
