import React, { useEffect, useState } from "react";
import { Container, Row, Col, Alert, Spinner, Button, Table } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import axiosInstance from "../axiosInstance";
import ModalComponent from "../components/ModalComponent";

const CategoriesPage = () => {
  const [categories, setCategories] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const [selectedCategoryId, setSelectedCategoryId] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    loadCategories();
  }, []);

  const loadCategories = () => {
    setLoading(true);
    axiosInstance
      .get("api/category")
      .then((response) => {
        setCategories(response.data);
        setError(null);
      })
      .catch((error) => {
        console.error("Error fetching categories:", error);
        setError("Failed to load categories. Please try again later.");
      })
      .finally(() => setLoading(false));
  };

  const handleDeleteClick = (categoryId) => {
    setSelectedCategoryId(categoryId);
    setShowModal(true);
  };

  const handleConfirmDelete = () => {
    axiosInstance
      .delete(`api/category/${selectedCategoryId}`)
      .then(() => {
        loadCategories();
        setShowModal(false);
      })
      .catch((error) => {
        console.error("Error deleting category:", error);
        setError("Failed to delete category");
      });
  };

  if (loading) {
    return (
      <Container className="d-flex justify-content-center align-items-center" style={{ minHeight: "400px" }}>
        <Spinner animation="border" role="status">
          <span className="visually-hidden">Loading...</span>
        </Spinner>
      </Container>
    );
  }

  return (
    <Container className="mt-4 px-3 mb-5" dir="rtl">
      <Row className="mb-4">
        <Col>
          <h1>دسته‌بندی‌ها</h1>
        </Col>
        <Col className="text-start">
          <Button variant="primary" onClick={() => navigate("/create/category")}>
            افزودن دسته‌بندی جدید
          </Button>
        </Col>
      </Row>

      {error && <Alert variant="danger">{error}</Alert>}

      <Table striped bordered hover>
        <thead>
          <tr>
            <th>نام</th>
            <th>عملیات</th>
          </tr>
        </thead>
        <tbody>
          {categories.map((category) => (
            <tr key={category.id}>
              <td>{category.name}</td>
              <td>
                <Button
                  variant="warning"
                  className="me-2"
                  onClick={() => navigate(`/edit/category/${category.id}`)}
                >
                  ویرایش
                </Button>
                <Button
                  variant="danger"
                  onClick={() => handleDeleteClick(category.id)}
                >
                  حذف
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

      <ModalComponent
        show={showModal}
        onHide={() => setShowModal(false)}
        modalTitle="حذف دسته‌بندی"
        modalBody="آیا از حذف این دسته‌بندی اطمینان دارید؟"
        OnOk={handleConfirmDelete}
        cancleBtnTitle="انصراف"
        okBtnTitle="حذف"
      />
    </Container>
  );
};

export default CategoriesPage;
