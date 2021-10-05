import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import MarketplaceItem from "../marketplace-components/marketplace-item"
import {Grid} from "@material-ui/core"
import axios from "axios";
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
  let style = useStyles();
  let props = [
    {
      id: 0,
      title: "123",
      image: "https://sk.basketzone.net/zdjecia/2020/06/22/706/07/NIKE_AIR_JORDAN_1_RETRO_MID_CHICAGO.jpg",
      name: "Air jordans, Air jordans",
      price: "299.00€"
    },
    {
      id: 1,
      title: "123",
      image: "https://sk.basketzone.net/zdjecia/2020/06/22/706/07/NIKE_AIR_JORDAN_1_RETRO_MID_CHICAGO.jpg",
      name: "Air jordans",
      price: "299.00€"
    },
    {
      id: 2,
      title: "123",
      image: "https://sk.basketzone.net/zdjecia/2020/06/22/706/07/NIKE_AIR_JORDAN_1_RETRO_MID_CHICAGO.jpg",
      name: "Air jordans",
      price: "299.00€"
    },
    {
      id: 3,
      title: "123",
      image: "https://sk.basketzone.net/zdjecia/2020/06/22/706/07/NIKE_AIR_JORDAN_1_RETRO_MID_CHICAGO.jpg",
      name: "Air jordans",
      price: "299.00€"
    },
    {
      id: 4,
      title: "123",
      image: "https://sk.basketzone.net/zdjecia/2020/06/22/706/07/NIKE_AIR_JORDAN_1_RETRO_MID_CHICAGO.jpg",
      name: "Air jordans",
      price: "299.00€"
    },
    {
      id: 5,
      title: "123",
      image: "https://sk.basketzone.net/zdjecia/2020/06/22/706/07/NIKE_AIR_JORDAN_1_RETRO_MID_CHICAGO.jpg",
      name: "Air jordans",
      price: "299.00€"
    },
    {
      id: 6,
      title: "123",
      image: "https://sk.basketzone.net/zdjecia/2020/06/22/706/07/NIKE_AIR_JORDAN_1_RETRO_MID_CHICAGO.jpg",
      name: "Air jordans",
      price: "299.00€"
    },
    {
      id: 7,
      title: "123",
      image: "https://sk.basketzone.net/zdjecia/2020/06/22/706/07/NIKE_AIR_JORDAN_1_RETRO_MID_CHICAGO.jpg",
      name: "Air jordans",
      price: "299.00€"
    },
  ]
  const url = "http://localhost:5000/api/Drops/item/all"
  const [items, setItems] = useState([]);
  useEffect(() => {
    axios.get(url, {
      headers: {
        'Access-Control-Allow-Origin': 'localhost:5000'
      }
    })
    .then((response) => {
      setItems(response.data.item.result);
    })
    .catch((error) => {
      console.debug(error)
    })
  }, [])
  console.debug(items);

    return (
        <div className={style.div}>
          <Typography>/ Drop Week 0</Typography>
          <Typography>Every Saturday we sell items at retail prices, at the basis of first come first served!</Typography>
          <Grid container spacing={4} className={style.grid}>
              {items.map((gridItem) =>(
                <Grid item>
                  <MarketplaceItem key={gridItem.key} {... gridItem}></MarketplaceItem>
                </Grid>
              ))}
          </Grid>

        </div>
    )

}
export default Market;