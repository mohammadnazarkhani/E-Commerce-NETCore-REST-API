import React from "react";
import {
  Route,
  createBrowserRouter,
  createRoutesFromElements,
  RouterProvider,
} from "react-router-dom";
import MainLayout from "./layouts/MainLayout";
import HomePage from "./pages/HomePage";
import ProductPage from "./pages/ProductPage";
import AddNewProductPage from "./pages/AddNewProductPage";
import EditProductPage from "./pages/EditProductPage";

const App = () => {
  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={<MainLayout />}>
        <Route index element={<HomePage />} />
        <Route path="/product/:id" element={<ProductPage />} />
        <Route path="/create/product" element={<AddNewProductPage />} />
        <Route path="/edit/product/:id" element={<EditProductPage />} />
      </Route>
    )
  );
  return <RouterProvider router={router} />;
};

export default App;
