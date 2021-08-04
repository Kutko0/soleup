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
    }

}));

let Market = function() {
    const classes = makeStyles()
    return (
        <div>
          <Typography>Featured On Market</Typography>
            <GridList>
              <GridListTile key="Subheader" cols={2}>
            <ListSubheader component="div"> Drips_Hub store </ListSubheader>
          </GridListTile>
          <GridListTile>
            <MarketplaceItem></MarketplaceItem>
            <MarketplaceItem></MarketplaceItem>
          </GridListTile>
        </GridList>
        <Box display="flex" justifyContent="center" height="50px">
          <Button className={classes.buttonStyle}>Explore this store</Button>
        </Box>
        <GridList>
          <GridListTile key="Subheader" cols={2}>
            <ListSubheader component="div"> Week 5 FCFS Raffle </ListSubheader>
          </GridListTile>
          <GridListTile>
            <MarketplaceItem></MarketplaceItem>
            <MarketplaceItem></MarketplaceItem>
          </GridListTile>
        </GridList>
        <Box display="flex" justifyContent="center" height="50px">
          <Button className={classes.buttonStyle}>Explore this store</Button>
        </Box>

        </div>
    )

}
export default Market;