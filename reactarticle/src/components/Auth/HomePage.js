import React, { useState } from "react";
import { Button } from "semantic-ui-react";
import "../../App.css";
import Login from "./Login";
import Register from "./Register";
import Modal from "react-modal";

export default function HomePage() {
  const [Page, setPage] = useState("");
  const [modalIsOpen, setmodalIsOpen] = useState(false);
  const targetValue = (event) => {
    setPage(event.target.innerText);
  };
  return (
    <div className="homePage">
      <div onClick={(event) => targetValue(event)}>
        <Button size="massive" onClick={() => setmodalIsOpen(true)} inverted color="yellow">
          Giriş
        </Button>
        <Button size="massive" onClick={() => setmodalIsOpen(true)} inverted color="olive">
          Kayıt
        </Button>
      </div>
      <Modal className="Modal" isOpen={modalIsOpen} onRequestClose={() => setmodalIsOpen(false)}>
        {Page === "Giriş" ? <Login /> : <Register />}
      </Modal>
    </div>
  );
}
