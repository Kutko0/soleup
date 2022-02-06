import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import  Market  from '../marketplace-components/market-store'
import { CardMedia } from '@material-ui/core';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  paper: {
    height: 700,
    width: 450,
    backgroundColor: "#999"
  },
  control: {
    padding: theme.spacing(2),
  },
  center: {
    margin: "auto",
    textAlign: "center",
    fontFamily: "Impact"
  },
}));


let Home = function() {
    const classes = useStyles();
    return (
        <div>
          <Typography className={classes.center} variant="h3">
            READY TO SOLEUP?
          </Typography>
          <Grid container
            spacing={0}
            direction="row"
            alignItems="center"
            justify="center" spacing={2}>
            <Grid item xs={3}>
                <CardMedia
                  className={classes.paper}
                  title="props.mediaName"
                  image="https://cdn.shopify.com/s/files/1/0228/5309/1392/files/Jy8pCpEVSjk.jpg?v=1615994371"
                >

                </CardMedia>
            </Grid>
            <Grid item xs={3}>
              <CardMedia
                  className={classes.paper}
                  title="props.mediaName"
                  image="https://cdn.shopify.com/s/files/1/0228/5309/1392/files/fXXCxVlCWCI.jpg?v=1615994396"
                >

              </CardMedia>

            </Grid>
            <Grid item xs={3}>
            <CardMedia
                  className={classes.paper}
                  title="props.mediaName"
                  image="https://cdn.shopify.com/s/files/1/0228/5309/1392/files/3-66mOQ_2os.jpg?v=1615994415"
                >

              </CardMedia>
            </Grid>
          </Grid>
          <Market></Market>
        </div>
    )

}
export default Home;