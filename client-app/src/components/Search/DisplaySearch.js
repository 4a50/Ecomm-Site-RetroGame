import React from 'react';
import Card from 'react-bootstrap/Card';
let DisplaySearch = (props) => {
  console.log('Display Search:', props);
  return (
    <>
      <h1>Search Query: {props.gameList[0].name}</h1>
      {props.gameList.map(game =>
        <Card>
          <div className="d-inline-flex">
            <img alt={`Boxart of ${game.name}`} style={{ width: '20rem' }} src={game.boxArtUrlFront} />

            <p className="p-5">{game.name}</p>
            <p>Test</p>
          </div>
        </Card>
      )
      }
    </>
  );
}

export default DisplaySearch;