import React, { useEffect, useState } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import sampleData from './sampleData/sampleServerResponse.json';

import './custom.css'
import Carousel from 'react-bootstrap/Carousel';
import CarouselItem from './Carousel/CarouselItem.js';
import CarouselCard from './Carousel/CarouselCard.js'

export default function App(props) {
  const [inventoryData, setInventoryData] = useState([]);
  useEffect(() => {
    setInventoryData(sampleData);
  }, []);

  const populateInvData = () => {
    let arr = inventoryData;
    let carouselItemArr = [];
    let cardArr = []
    let counter = -1
    while (++counter < arr.length) {
      cardArr.push(arr[counter]);
      if (counter !== 0 && (counter + 1) % 3 === 0) {
        // console.log(counter);
        carouselItemArr.push(cardArr);
        // console.log('arrarr', carouselItemArr);
        cardArr = [];
      }
    }
    if (cardArr.length > 0) carouselItemArr.push(cardArr);
    console.log(carouselItemArr);
  }
  populateInvData();
  return (
    <Layout>
      <h1>{inventoryData.length}</h1>
      <Route exact path='/' component={Home} />
      <Route path='/counter' component={Counter} />
      <Route path='/fetch-data' component={FetchData} />
    </Layout>
  );
}
