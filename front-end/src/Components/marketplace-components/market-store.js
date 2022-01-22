import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import MarketplaceItem from "../marketplace-components/marketplace-item"
import {Grid} from "@material-ui/core"
import axios from "axios";
import {useEffect, useState} from "react";
import {GET_ALL_DROP_ITEMS, POST_DROP_USER_ENROLL} from "../../apiCalls/apiUrl.js";
//import {BrowserView, MobileView} from 'react-device-detect';
import MediaQuery from 'react-responsive';
//import {checkToken} from "../../apiCalls/apiUrl.js";

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
      width: "auto",
      padding: "10px",
      heigth: "1300px",
      justifyContent: "center"

     },
     grid: {
       justifyContent: "center"
     }

}));

//let Market = function()
let Market = (props) => {
  let style = useStyles();
  //const url = "http://localhost:5000/api/Drops/item/all"
  const [items, setItems] = useState([]);
  useEffect(() => {
    axios.get(GET_ALL_DROP_ITEMS, {
      headers: {
        'Access-Control-Allow-Origin': 'localhost:5000'
      }
    })
    .then((response) => {
      setItems(response.data.item);
    })
    .catch((error) => {
      console.debug(error)
    })
  }, [])
  console.debug(items);

    return (
        <div className={style.div}>
          <Typography>Drop Week 0</Typography>
          <MediaQuery maxDeviceWidth={700}>
            <Typography>Every Saturday we sell items</Typography>
            <Typography>at retail prices, at the basis</Typography>
            <Typography>of first come first served!</Typography>
          </MediaQuery>
          <MediaQuery minDeviceWidth={700}>
            <Typography>Every Saturday we sell items at retail prices, at the basis of first come first served!</Typography>
           </MediaQuery>
          <Grid container spacing={4} className={style.grid}>
              {items.map((gridItem) =>(
                <Grid item>
                  <MarketplaceItem key={gridItem.key} {... gridItem} blockButtonToken={props.location}></MarketplaceItem>
                </Grid>
              ))}
          </Grid>

        </div>
    )

}
export default Market;