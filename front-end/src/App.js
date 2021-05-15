import LoginScreen from './pages/LoginPage'

import TextField from "@material-ui/core/TextField";
let username;

function setState(e){
  console.debug(e)
  username = e

}
function App() {

  return (
      <LoginScreen />
  )
}

export default App;
