import React from 'react';
import CarouselDisplay from './Carousel/CarouselDisplay';

const Main = (props) => {
  return (
    <>
      {props.invData.length > 0 && <CarouselDisplay invData={props.invData} />}

    </>
  )
}

export default Main;