import { Card, CardActionArea, CardActions, CardContent, Typography } from "@material-ui/core"
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import { Container, Grid } from "@material-ui/core";
import {Link} from 'react-router-dom';
import PersonIcon from '@material-ui/icons/Person';
import ShoppingCartIcon from '@material-ui/icons/ShoppingCart';
import React from 'react';
import Dialog from '@material-ui/core/Dialog';
import DialogContent from '@material-ui/core/DialogContent';
import LoginScreen from '../../pages/LoginPage';


const useStyles = makeStyles((theme) => ({
    root: {
      height: "100px",
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
      height: "150px",
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
      fontSize: 12,
      fontFamily: 'Oswald'
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
    const [open, setOpen] = React.useState(false);

    const handleClickOpen = () => {
      setOpen(true);
    };

    const handleClose = () => {
      setOpen(false);
    };
    return(
        <div className={classes.root}>
            <CardActions>
              <Typography variant="h3" style={{fontFamily: 'Oswald', fontWeight: 'bold'}}>
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
                <Grid item className={classes.gridItem} xs={6}>
                  <Link to="/fcfsRaffles" className={classes.link}>
                    <Typography className={classes.textDecor}>
                      FCFS RAFFLES
                    </Typography>
                  </Link>
                </Grid>
                <div className={classes.divider}></div>
                <Grid item className={classes.gridItem} justify="end">
                  <Button
                    onClick={handleClickOpen}
                  >
                    <PersonIcon></PersonIcon>
                  </Button>
                  <Button>
                    <ShoppingCartIcon></ShoppingCartIcon>
                  </Button>
                </Grid>
              </Grid>
            </CardActions>
          <Dialog open={open} onClose={handleClose}>
            <DialogContent
              style={{height:'280px', width: "280px"}}
              >
              <LoginScreen></LoginScreen>
            </DialogContent>
          </Dialog>
        </div>
    )
}

export default MarketplaceNavigation;