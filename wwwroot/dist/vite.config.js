import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import path from "path";

export default defineConfig({
  plugins: [react()],
  root: "./React",
  base: "/dist/",
  build: {
    outDir: path.resolve(__dirname, "wwwroot/dist"),
    emptyOutDir: true,
    rollupOptions: {
      input: path.resolve(__dirname, "React/main.jsx"),
      output: {
        // fixed names so Razor can reference them easily
        entryFileNames: "assets/app.js",
        chunkFileNames: "assets/chunk-[name].js",
        assetFileNames: "assets/[name][extname]"
      }
    }
  },
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "React")
    }
  },
  server: {
    port: 3000,
    strictPort: true
  }
});