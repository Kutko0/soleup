import GridList from '@material-ui/core/GridList';
import Button from '@material-ui/core/Button';
import GridListTile from '@material-ui/core/GridListTile';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import MarketplaceItem from "../marketplace-components/marketplace-item"
import Box from '@material-ui/core/Box';
import { Container, Grid, ListSubheader } from "@material-ui/core"

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
      heigth: "1300px"

     }

}));

let Market = function() {
    const classes = useStyles()
    return (
        <div className={classes.div}>
          <Typography>/ Preview of Drop Week 115</Typography>
          <Typography>These are three of the seventy items that we will be dropping for RETAIL this Saturday. All kinds of hyped clothing and hyped sneaker brands for retail. A membership is required to participate in our weekly retail drops. Click on the membership page to purchase one or to find out when the next restock is happening!</Typography>
          <Grid container>
            <Grid item>
              <MarketplaceItem></MarketplaceItem>
            </Grid>
            <Grid item>
              <MarketplaceItem></MarketplaceItem>
            </Grid>
            <Grid item>
            <MarketplaceItem></MarketplaceItem>
            </Grid>
            <Grid item>
            <MarketplaceItem></MarketplaceItem>
            </Grid>
            <Grid item>
            <MarketplaceItem></MarketplaceItem>
            </Grid>
            <Grid item>
            <MarketplaceItem></MarketplaceItem>
            </Grid>
            <Grid item>
            <MarketplaceItem></MarketplaceItem>
            </Grid>
            <Grid item>
            <MarketplaceItem></MarketplaceItem>
            </Grid>
          </Grid>

        </div>
    )

}
export default Market;