import { Card, CardActionArea, CardActions, CardContent, Typography } from "@material-ui/core"
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import { Container, Grid } from "@material-ui/core";
import {Link} from 'react-router-dom';
import PersonIcon from '@material-ui/icons/Person';
import ShoppingCartIcon from '@material-ui/icons/ShoppingCart';
const useStyles = makeStyles((theme) => ({
    root: {
      height: "170px",
      marginTop: "10px",
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
    gridItem: {
      display:"flex",
      marginLeft: "50px"
    },
    divider: {
      marginRight: "80px"
    },
    textDecor: {
      fontWeight: 'bold',
      fontSize: 14,
      fontFamily: 'ArialBlack'
    },
    link: {
      textDecoration: 'none',
      color: "black",
      '&:hover': {
        textDecoration: "underline"
      },
      '&:active': {
        textDecoration: "underline"
      },
      '&:visited': {
        textDecoration: "underline"
      },
      '&:focus': {
        textDecoration: "underline"
      }
    }
}));


let MarketplaceNavigation = function(){
    const classes = useStyles()
    return(
        <Card className={classes.root}>
            <CardActions>
              <Typography variant="h3">
                SoleUP
              </Typography>
              <Grid container
                direction="row"
                justify="left"
                alignItems="center"
              >
                <div className={classes.divider}></div>
                <Grid item className={classes.gridItem}>
                  <Link to="/" className={classes.link}>
                    <Typography className={classes.textDecor}>
                      HOME
                    </Typography>
                  </Link>
                </Grid>
                <Grid item  className={classes.gridItem}>
                  <Link to="/market" className={classes.link}>
                    <Typography className={classes.textDecor}>
                      MARKET
                    </Typography>
                  </Link>
                </Grid>
                <Grid item className={classes.gridItem}>
                  <Link to="/news" className={classes.link}>
                    <Typography className={classes.textDecor}>
                      NEWS
                    </Typography>
                  </Link>
                </Grid>
                <Grid item className={classes.gridItem}>
                  <Link to="/auctions" className={classes.link}>
                    <Typography className={classes.textDecor}>
                      AUCTIONS
                    </Typography>
                  </Link>
                </Grid>
                <Grid item className={classes.gridItem}>
                  <Link to="/fcfsRaffles" className={classes.link}>
                    <Typography className={classes.textDecor}>
                      FCFS RAFFLES
                    </Typography>
                  </Link>
                </Grid>
                <Grid item className={classes.gridItem} justify="end">
                  <Button>
                    <PersonIcon></PersonIcon>
                  </Button>
                  <Button>
                    <ShoppingCartIcon></ShoppingCartIcon>
                  </Button>
                </Grid>
              </Grid>
            </CardActions>
            <CardContent className={classes.center}>
              <Typography className={classes.center} variant="h3">
                READY TO SOLEUP?
              </Typography>
            </CardContent>
        </Card>
    )
}

export default MarketplaceNavigation;