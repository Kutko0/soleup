import GridList from '@material-ui/core/GridList';
import Button from '@material-ui/core/Button';
import GridListTile from '@material-ui/core/GridListTile';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import MarketplaceItem from "../marketplace-components/marketplace-item"
import Box from '@material-ui/core/Box';
import { Container, Grid, ListSubheader } from "@material-ui/core"
import axios from "axios";
import { render } from '@testing-library/react';
import {useEffect, useState} from "react";

const useStyles = makeStyles((theme) => ({
    root: {
      backgroundColor: "grey",
    },
    navigation: {
        marginLeft: "auto",
        marginRight: "auto",
    },
    centerButton: {
      height: "200px"
    },
    buttonStyle: {
      color: "#212121"
      },
    div: {
      margin: "auto",
      width: "1300px",
      padding: "10px",
      heigth: "1300px",
      justifyContent: "center"

     },
     grid: {
       justifyContent: "center"
     }

}));


//let Market = function()
let Market = () => {
  let style = makeStyles();
  let props = [
    {
      title: "123",
      image: "https://sk.basketzone.net/zdjecia/2020/06/22/706/07/NIKE_AIR_JORDAN_1_RETRO_MID_CHICAGO.jpg",
      name: "Air jordans, Air jordans",
      price: "299.00€"
    },
    {
      title: "123",
      image: "https://sk.basketzone.net/zdjecia/2020/06/22/706/07/NIKE_AIR_JORDAN_1_RETRO_MID_CHICAGO.jpg",
      name: "Air jordans",
      price: "299.00€"
    },
    {
      title: "123",
      image: "https://sk.basketzone.net/zdjecia/2020/06/22/706/07/NIKE_AIR_JORDAN_1_RETRO_MID_CHICAGO.jpg",
      name: "Air jordans",
      price: "299.00€"
    },
    {
      title: "123",
      image: "https://sk.basketzone.net/zdjecia/2020/06/22/706/07/NIKE_AIR_JORDAN_1_RETRO_MID_CHICAGO.jpg",
      name: "Air jordans",
      price: "299.00€"
    },
    {
      title: "123",
      image: "https://sk.basketzone.net/zdjecia/2020/06/22/706/07/NIKE_AIR_JORDAN_1_RETRO_MID_CHICAGO.jpg",
      name: "Air jordans",
      price: "299.00€"
    },
    {
      title: "123",
      image: "https://sk.basketzone.net/zdjecia/2020/06/22/706/07/NIKE_AIR_JORDAN_1_RETRO_MID_CHICAGO.jpg",
      name: "Air jordans",
      price: "299.00€"
    },
    {
      title: "123",
      image: "https://sk.basketzone.net/zdjecia/2020/06/22/706/07/NIKE_AIR_JORDAN_1_RETRO_MID_CHICAGO.jpg",
      name: "Air jordans",
      price: "299.00€"
    },
  ]
  var config = {
    headers: {'Access-Control-Allow-Origin': 'localhost:5000'}
};
  const url = "http://localhost:5000/api/Drops/item/all"
  const headers = {"Access-Control-Allow-Origin": "*"}
  //axios.defaults.adapter = require('axios/lib/adapters/http')
  const [items, setItems] = useState([]);
  // const [post, setPost] = React.useState(null);
  //  React.useEffect(() => {
  useEffect(() => {
    axios.get(url, {
      headers: {
        'Access-Control-Allow-Origin': 'localhost:5000'
      }
    })
    .then((response) => {
      setItems(response.data);
    })
    .catch((error) => {
      console.debug(error)
    })
  })
  console.debug(items);
//  }, []);
  
  //const styles = useStyles()
    return (
        <div className={style.div}>
          <Typography>/ Drop Week 0</Typography>
          <Typography>Every Saturday we sell items at retail prices, at the basis of first come first served!</Typography>
          <Grid container spacing={4} className={style.grid}>
              {props.map(item=>(
                <Grid item>
                  <MarketplaceItem {... item}></MarketplaceItem>
                </Grid>
              ))}
          </Grid>

        </div>
    )

}
export default Market;