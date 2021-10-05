import {  CardActions, Typography } from "@material-ui/core"
import { makeStyles } from '@material-ui/core/styles';
import { Grid } from "@material-ui/core";
import {Link} from 'react-router-dom';
import React from 'react';

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
    return(
        <div className={classes.root}>
            <CardActions>
              <Typography variant="h3" style={{fontFamily: 'Oswald', fontWeight: 'bold'}}>
                SoleUP
              </Typography>
              <Grid container
                direction="row"
                justify="flex-start"
                alignItems="center"
              >
                <div className={classes.divider}></div>
                <Grid item  className={classes.gridItem}>
                  <Link to="/" className={classes.link}>
                    <Typography className={classes.textDecor}>
                      FCFS Raffles
                    </Typography>
                  </Link>
                </Grid>
                <div className={classes.divider}></div>
              </Grid>
            </CardActions>
        </div>
    )
}

export default MarketplaceNavigation;