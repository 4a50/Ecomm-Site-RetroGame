import React, { useState } from 'react';
import {
  Routes,
  Route
} from "react-router-dom";
import { Layout } from './components/Layout';
import Main from './components/Main.js';
import sampleData from './sampleData/sampleServerResponse.json';
import AdminPanel from './components/AdminPanel/AdminPanel.js'

import './custom.css'

function App(props) {

  const [inventoryData] = useState([sampleData]);

  return (
    <Layout>
      <Routes>
        <Route exact path="/" element={<Main invData={inventoryData} />} />
        <Route exact path="/admin-panel" element={<AdminPanel inventoryData={inventoryData} />} />
      </Routes>
    </Layout>
  );

}
export default App