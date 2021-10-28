import React from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import Main from './components/Main.js';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import sampleData from './sampleData/sampleServerResponse.json';

import './custom.css'

export default class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      inventoryData: []
    }
  }

  componentDidMount() {
    this.setState({
      inventoryData: sampleData
    });

  }


  render() {
    // console.log('APP STATE:', this.state);
    return (
      <Layout>
        <h1>{this.state.inventoryData.length}</h1>
        <Route exact path='/'>
          <Main invData={this.state.inventoryData} />
        </Route>
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
      </Layout>
    );
  }
}
