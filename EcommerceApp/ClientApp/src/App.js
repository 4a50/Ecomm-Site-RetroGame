import React, { useState, useEffect } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/Layout';
import Main from './components/Main.js';
import sampleData from './sampleData/sampleServerResponse.json';
import AdminPanel from './components/AdminPanel/AdminPanel.js'

import './custom.css'

function App(props) {

  const [inventoryData, setInventoryData] = useState([sampleData]);

  return (
    <Layout>
      <Switch>
        <Route exact path="/">
          <Main invData={inventoryData} />
        </Route>
        <Route exact path="/admin">
          <AdminPanel inventoryData={inventoryData} />
        </Route>
      </Switch>

    </Layout>
  );

}
export default App