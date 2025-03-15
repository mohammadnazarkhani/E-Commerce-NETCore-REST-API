import React from "react";

const Logo = () => (
  <svg
    width="120"
    height="60"
    viewBox="0 0 40 60"
    xmlns="http://www.w3.org/2000/svg"
    style={{ display: "block", margin: 0, padding: 0 }} // Ensure the SVG has no margin or padding
  >
    <polygon points="50,0 30,40 50,40 20,60 40,20 20,20" fill="url(#grad1)" />
    <defs>
      <linearGradient id="grad1" x1="0%" y1="0%" x2="100%">
        <stop offset="0%" style={{ stopColor: "#FF5733", stopOpacity: 1 }} />
        <stop offset="100%" style={{ stopColor: "#FFC300", stopOpacity: 1 }} />
      </linearGradient>
    </defs>
    <text
      x="71"
      y="40"
      fontFamily="Arial, sans-serif"
      fontSize="24"
      fill="url(#grad2)"
      fontWeight="bold"
    >
      تند‌فروش
    </text>
    <defs>
      <linearGradient id="grad2" x1="0%" y1="0%" x2="100%">
        <stop offset="0%" style={{ stopColor: "#DAF7A6", stopOpacity: 1 }} />
        <stop offset="100%" style={{ stopColor: "#FF5733", stopOpacity: 1 }} />
      </linearGradient>
    </defs>
  </svg>
);

export default Logo;
