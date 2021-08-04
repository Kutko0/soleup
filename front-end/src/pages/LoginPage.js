import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import Grid from "@material-ui/core/Grid";
import Paper from "@material-ui/core/Paper";
import { makeStyles } from "@material-ui/core/styles";
import Typography from "@material-ui/core/Typography";
import Toolbar from "@material-ui/core/Toolbar";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1
  },
  button: {
    width: "250px",
    marginLeft:"20px",
    borderRadius: 0
  },
  textField: {
    marginLeft: "20px",
    width: "250px"
  },
  paper: {
    width:"300px",
    height:"250px"
  }
}));
let username;
let password;
function setUsernameState(e){
  username = e
}

function setPasswordState(e){
 password = e
}

let LoginScreen = function() {
  const classes = useStyles();
  return (
  <div
  style={{
  }}
  >
      <Grid container spacing={1}>
        <Toolbar>
          <Typography variant="h5">SoleUP login Page</Typography>
        </Toolbar>
        <Grid item xs={12}>
          <TextField
            value={username}
            onChange={(e) => {setUsernameState(e.target.value)}}
            className={classes.textField}
            id="standard-basic"
            label="Username"
          />
        </Grid>
        <Grid item xs={12}>
          <TextField
            value={password}
            onChange={(e) => {setPasswordState(e.target.value)}}
            className={classes.textField}
            id="standard-basic"
            label="Password"
          />
        </Grid>
        <Grid item xs={16} justify="space-between">
          <Button
            className={classes.button}
            variant="contained"
            onClick={apiCall()}
            color="primary"
          >
            Login
          </Button>
        </Grid>
        <Grid item xs={12}>
          Don't have an account?
          <Button size="small" onClick={registerCall()}className={useStyles.button}>
            {" "}
            Register
          </Button>
        </Grid>
      </Grid>
  </div>
  );
}
function apiCall() {
  //call na prihlasenie sa
  let payload = {
    username: username,
    password: password,
    //id?
    //
  }
}
function registerCall() {
  //registracia
}
export default LoginScreen;