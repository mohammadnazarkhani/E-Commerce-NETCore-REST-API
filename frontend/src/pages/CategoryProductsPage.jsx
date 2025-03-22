import React, { useEffect, useState } from "react";
import { Container, Row, Col, Alert, Spinner, Breadcrumb } from "react-bootstrap";
import { useParams, useNavigate } from "react-router-dom";
import axiosInstance from "../axiosInstance";
import ProductCard from "../components/ProductCard";

const CategoryProductsPage = () => {
  const { categoryId } = useParams();
  const navigate = useNavigate();
  const [products, setProducts] = useState([]);
  const [category, setCategory] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const [productsRes, categoryRes] = await Promise.all([
          axiosInstance.get(`api/product/category/${categoryId}`),
          axiosInstance.get(`api/category/${categoryId}`)
        ]);
        
        setProducts(productsRes.data);
        setCategory(categoryRes.data);
        setError(null);
      } catch (error) {
        console.error("Error fetching data:", error);
        setError("Failed to load products");
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, [categoryId]);

  if (loading) {
    return (
      <Container className="d-flex justify-content-center align-items-center" style={{ minHeight: "400px" }}>
        <Spinner animation="border" />
      </Container>
    );
  }

  return (
    <Container className="mt-4 px-3 mb-5">
      <Breadcrumb dir="rtl" className="mt-3">
        <Breadcrumb.Item href="/">خانه</Breadcrumb.Item>
        <span className="mx-2" style={{ color: '#6c757d' }}>/</span>
        <Breadcrumb.Item active>{category?.name}</Breadcrumb.Item>
      </Breadcrumb>

      {error ? (
        <Alert variant="danger">{error}</Alert>
      ) : (
        <Row className="g-4">
          {products.length === 0 ? (
            <Col>
              <Alert variant="info">محصولی در این دسته‌بندی وجود ندارد.</Alert>
            </Col>
          ) : (
            products.map((product) => (
              <Col key={product.id} md={4} sm={6} xs={12}>
                <ProductCard
                  product={product}
                  onClick={() => navigate(`/product/${product.id}`)}
                />
              </Col>
            ))
          )}
        </Row>
      )}
    </Container>
  );
};

export default CategoryProductsPage;
