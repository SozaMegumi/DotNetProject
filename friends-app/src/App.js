import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import StudyGroupForm from "./components/StudyGroupForm";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<StudyGroupForm />} />
      </Routes>
    </Router>
  );
}

export default App;