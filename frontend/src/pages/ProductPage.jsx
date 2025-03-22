import React, { use, useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { Button, Breadcrumb } from "react-bootstrap";
import axiosInstance from "../axiosInstance";
import "../styles/ProductPage.css"; // Import the CSS file from the styles folder
import ModalComponent from "../components/ModalComponent";

const ProductPage = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [product, setProduct] = useState(null);
  const [loading, setLoading] = useState(true);
  const [showModal, setShowModal] = useState(false);

  const OnConfirmDeletion = () => {
    axiosInstance
      .delete(`api/product/${id}`)
      .then(() => {
        navigate("/");
      })
      .catch((error) => {
        console.error("Can't delete product:", error);
      })
      .finally(() => {
        setShowModal(false);
      });
  };

  useEffect(() => {
    if (!id) {
      console.error("Invalid product id:", id);
      return;
    }

    axiosInstance
      .get(`api/product/${id}`)  // Changed to match ProductController route
      .then((res) => {
        if (res.data && typeof res.data === 'object') {
          setProduct(res.data);
        } else {
          console.error("Invalid product data received");
          setProduct(null);
        }
        setLoading(false);
      })
      .catch((err) => {
        console.error("Error fetching product:", err?.response?.data || err.message);
        setProduct(null);
        setLoading(false);
      });
  }, [id]);

  if (loading) {
    return (
      <div className="container mt-4 px-3 mb-5 text-center">
        <div className="spinner"></div>
      </div>
    );
  }

  if (!product) {
    return (
      <div className="container mt-4 px-3 mb-5 text-center">
        <div className="alert">Product not found.</div>
      </div>
    );
  }

  return (
    <div className="container mt-4 px-3 mb-5">
      <Breadcrumb dir="rtl" className="mt-3">
        <Breadcrumb.Item href="/">خانه</Breadcrumb.Item>
        <span className="mx-2" style={{ color: '#6c757d' }}>/</span>
        <Breadcrumb.Item href={`/product/category/${product.categoryId}`}>
          {product.categoryName}
        </Breadcrumb.Item>
        <span className="mx-2" style={{ color: '#6c757d' }}>/</span>
        <Breadcrumb.Item active>{product.name}</Breadcrumb.Item>
      </Breadcrumb>
      <div className="product-container">
        <img
          src={product.imageUrl}
          alt={product.name}
          className="product-image"
        />
        <h1 className="product-title">{product.name}</h1>
        <p className="product-description">{product.description}</p>
        <p className="product-price">${product.price}</p>
        <Button
          variant="warning"
          onClick={() => navigate(`/edit/product/${id}`)}
          className="mt-3"
        >
          ویرایش محصول
        </Button>
        <Button variant="danger" onClick={() => setShowModal(true)} className="mt-3">
          حذف محصول
        </Button>
        <ModalComponent
          modalTitle="حذف محصول"
          modalBody="آیا از حذف محصول اطمینان دارید؟"
          OnOk={OnConfirmDeletion}
          cancleBtnTitle="انصراف"
          okBtnTitle="حذف"
          show={showModal}
          onHide={() => setShowModal(false)}
        />
      </div>
    </div>
  );
};

export default ProductPage;
