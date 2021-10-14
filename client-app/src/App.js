import { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Header from './components/Header/Header.js';
import Main from './components/Main';
function App() {
  const [gameArr, setGameArr] = useState([]);

  return (
    <>
      <Header />
      <Main />
      <Button>Get All Games</Button>
    </>
  );
}

export default App;
