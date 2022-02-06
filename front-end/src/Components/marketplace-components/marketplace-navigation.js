import { makeStyles } from '@material-ui/core/styles';
import React from 'react';
import dropsWithDripsLogo from '../../Images/dropsWithDripsLogo.jpg'
import MediaQuery from 'react-responsive';
const useStyles = makeStyles((theme) => ({
    root: {
      height: "110px",
      margin: "auto",
      backgroundColor: "black"
    },
    center: {
      margin: "auto",
      textAlign: "center"
    },
    media: {
      height: "100px",
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
            <MediaQuery minDeviceWidth={550}>
              <img
                src={dropsWithDripsLogo}

              >
              </img>
            </MediaQuery>
            <MediaQuery maxDeviceWidth={550}>
              <img
                src={dropsWithDripsLogo}
                width="320"
              >
              </img>
            </MediaQuery>
        </div>
    )
}

export default MarketplaceNavigation;