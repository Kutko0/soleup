import { Card, CardActionArea, CardActions, CardContent, Typography } from "@material-ui/core"
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import { Container, Grid } from "@material-ui/core"
const useStyles = makeStyles((theme) => ({
    root: {
      backgroundColor: "#dedbd5",
      height: "111px",
      marginTop: "65px",
      margin: "auto"
    },
    center: {
      margin: "auto",
      textAlign: "center"
    },
    title: {
      fontSize: 14,
    },
    media: {
      height: "250px",
    },

}));


let MarketplaceNavigation = function(){
    const classes = useStyles()
    return(
        <Card className={classes.root}>
            <CardActions>
              <Grid container
                direction="row"
                justify="center"
                alignItems="center"
              >
                <Grid item xs={2}>
                  <Button>
                  Home
                  </Button>
                </Grid>
                <Grid item xs={2}>
                  <Button>
                    Market
                  </Button>
                </Grid>
                <Grid item xs={2}>
                  <Button>
                    News
                  </Button>
                </Grid>
                <Grid item xs={2}>
                  <Button>
                    Auctions
                  </Button>
                </Grid>
                <Grid item xs={2}>
                  <Button>
                    FCFS Raffles
                  </Button>
                </Grid>
              </Grid>
            </CardActions>
            <CardContent className={classes.center}>
              <Typography className={classes.center}>
                READY TO SOLEUP?
              </Typography>
            </CardContent>
              <Button>
              </Button>
        </Card>
    )
}

export default MarketplaceNavigation;