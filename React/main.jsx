import React from "react";
import { createRoot } from "react-dom/client";
import CarouselComponent1 from "./components/CarouselComponent1";

const el = document.getElementById("react-root");
if (el) {
  createRoot(el).render(<CarouselComponent1 />);
}
