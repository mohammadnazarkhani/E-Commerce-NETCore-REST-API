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
import CategoriesPage from "./pages/CategoriesPage";
import AddNewCategoryPage from "./pages/AddNewCategoryPage";
import EditCategoryPage from "./pages/EditCategoryPage";
import CategoryProductsPage from "./pages/CategoryProductsPage";

class ErrorBoundary extends React.Component {
  state = { hasError: false };

  static getDerivedStateFromError(error) {
    return { hasError: true };
  }

  componentDidCatch(error, errorInfo) {
    console.error('Application Error:', error, errorInfo);
  }

  render() {
    if (this.state.hasError) {
      return <div>Something went wrong. Please refresh the page.</div>;
    }
    return this.props.children;
  }
}

const App = () => {
  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={<MainLayout />}>
        <Route index element={<HomePage />} />
        <Route path="/product/:id" element={<ProductPage />} />
        <Route path="/create/product" element={<AddNewProductPage />} />
        <Route path="/edit/product/:id" element={<EditProductPage />} />
        <Route path="/categories" element={<CategoriesPage />} />
        <Route path="/create/category" element={<AddNewCategoryPage />} />
        <Route path="/edit/category/:id" element={<EditCategoryPage />} />
        <Route path="/product/category/:categoryId" element={<CategoryProductsPage />} />
      </Route>
    )
  );

  return (
    <ErrorBoundary>
      <RouterProvider router={router} />
    </ErrorBoundary>
  );
};

export default App;
