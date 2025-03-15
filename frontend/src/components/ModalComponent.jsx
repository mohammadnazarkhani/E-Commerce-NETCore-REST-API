import React from "react";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";

const ModalComponent = ({
  modalTitle = "Modal heading",
  modalBody = "Modal Body",
  OnOk,
  cancleBtnTitle = "Cancel",
  okBtnTitle = "Ok",
  show = false,
  onHide
}) => {
  return (
    <Modal show={show} onHide={onHide}>
      <Modal.Header closeButton>
        <Modal.Title>{modalTitle}</Modal.Title>
      </Modal.Header>
      <Modal.Body>{modalBody}</Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onHide}>
          {cancleBtnTitle}
        </Button>
        <Button variant="primary" onClick={OnOk}>
          {okBtnTitle}
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default ModalComponent;
