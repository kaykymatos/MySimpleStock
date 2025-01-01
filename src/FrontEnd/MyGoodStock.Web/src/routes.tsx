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
        path: "/clients/edit",
        element: <ClientsPages.ClientEdit />,
      },
      {
        path: "/clients/delete",
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
        path: "/products/edit",
        element: <ProductsPages.ProductEdit />,
      },
      {
        path: "/products/delete",
        element: <ProductsPages.ProductDelete />,
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
        path: "/sales/edit",
        element: <SalesPages.SaleEdit />,
      },
      {
        path: "/sales/delete",
        element: <SalesPages.SaleDelete />,
      },

      {
        path: "/reports",
        element: <ReportPages.Reports />,
      },

      {
        path: "/login",
        element: <Login />,
      },
    ],
  },
]);
