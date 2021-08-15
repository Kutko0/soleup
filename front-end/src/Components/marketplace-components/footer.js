import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import { Paper, TextField } from '@material-ui/core';


const useStyles = makeStyles((theme) => ({
  root: {
    backgroundColor: 'black',
    marginTop: "35px",
    height: 180,
  },
   text: {
    color: "#999",
    fontFamily: "Oswald",
    fontSize: "15px",
    width: "550px",
    marginTop: "7px"
   },
   div: {
    margin: "auto",
    width: "10%",
    padding: "10px"

   }
}));


let Footer = function() {
    const classes = useStyles();
    return (
        <Paper className={classes.root}>
            <Grid container>
            <Grid item>
            <div className={classes.div}>
              <Typography className={classes.text}>
                CONTANT US
              </Typography>
              <Typography className={classes.text}>
                Reach us at INSERTEMAIL@MAIL.COM You'll receive a reaction within 24 hours on weekdays from 9AM-6PM CEST.
              </Typography>
            </div>
            </Grid>
            <Grid item>
            <div className={classes.div}>
              <Typography className={classes.text}>
                LINKS
              </Typography>
              <Typography className={classes.text}>
                  Home
              </Typography>
              <Typography className={classes.text}>
                  F.A.Q
              </Typography>
              <Typography className={classes.text}>
                  Shipping Policy
              </Typography>
              <Typography className={classes.text}>
                  Terms of Service
              </Typography>
            </div>
            </Grid>
            </Grid>
        </Paper>
    )

}
export default Footer;