import React from 'react';
import { useState, useEffect } from 'react';
import Carousel from 'react-bootstrap/Carousel'
import CarouselItem from '../Carousel/CarouselItem.js'
export default function CarouselDisplay(props) {

  // console.log('invDataCD', props);
  const populateInvData = () => {
    // console.log('popData');
    let dataArray = props.invData;
    // console.log('dataArray:', dataArray)
    let finalArray = [];
    let subArray = [];
    let counter = -1;

    while (++counter < dataArray.length) {
      subArray.push(dataArray[counter]);
      if (counter !== 0 && (counter + 1) % 3 === 0) {
        finalArray.push(subArray);
        subArray = [];
      }
    }
    if (counter <= finalArray.length - 1) finalArray.push(subArray);
    console.log('finalArray:', finalArray);
    return finalArray;

  }

  const [carouselData, setCarouselData] = useState([]);

  //TODO: Move the list of games information to the server.  Grab it on load and that's it.

  return (
    <>
      <h1>Carousel</h1>
      <h2>{carouselData.length} {props.invData.length}</h2>
      {carouselData.length > 0 &&
        <Carousel>
          {carouselData.map((collection, idx) =>
            <CarouselItem key={`ci-${idx}`} data={collection} />
          )}
        </Carousel>
      }
    </>
  )
}