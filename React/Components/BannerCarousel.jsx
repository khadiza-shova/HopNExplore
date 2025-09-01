import React, { useState } from "react";
import { FiChevronLeft, FiChevronRight } from "react-icons/fi";

export default function CarouselComponent1() {
  const [currentSlide, setCurrentSlide] = useState(0);

  const slides = [
    { id: 1, content: "Carousel 1 - Slide 1 Content", imgSrc: "~/images/HomePageImages/slide1.jpg" },
    { id: 2, content: "Carousel 1 - Slide 2 Content", imgSrc: "/caorusel_image/carousel-2.jpg" },
    { id: 3, content: "Carousel 1 - Slide 3 Content", imgSrc: "/caorusel_image/carousel-3.jpg" },
  ];

  const nextSlide = () => setCurrentSlide((p) => (p + 1) % slides.length);
  const prevSlide = () => setCurrentSlide((p) => (p - 1 + slides.length) % slides.length);

  return (
    <div className="relative flex items-center justify-center w-full h-[260px] rounded-lg overflow-hidden">
      <button
        type="button"
        aria-label="Previous slide"
        className="absolute left-3 p-2 bg-white/70 hover:bg-white rounded-full shadow"
        onClick={prevSlide}
      >
        <FiChevronLeft className="text-2xl" />
      </button>

      <img
        src={slides[currentSlide].imgSrc}
        alt={slides[currentSlide].content}
        className="w-full h-full object-cover"
      />

      <button
        type="button"
        aria-label="Next slide"
        className="absolute right-3 p-2 bg-white/70 hover:bg-white rounded-full shadow"
        onClick={nextSlide}
      >
        <FiChevronRight className="text-2xl" />
      </button>
    </div>
  );
}
