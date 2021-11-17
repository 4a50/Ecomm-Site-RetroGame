import { useState, useEffect } from 'react';
import Button from 'react-bootstrap/Button';
import Header from './components/Header/Header.js';
import Main from './components/Main';
import sampleData from '../src/sampleData/sampleServerResponse.json';
function App() {
  const [gameArr, setGameArr] = useState([]);
  useEffect(() => {
    console.log(sampleData);
  }, []);
  return (
    <>
      <h1>{gameArr.length}</h1>
      <Header />
      <Main />
      <Button>Get All Games</Button>
    </>
  );
}

export default App;
