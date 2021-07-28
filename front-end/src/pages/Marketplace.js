import MarketplaceItem from "../Components/marketplace-components/marketplace-item"
import MarketplaceAppBar from "../Components/marketplace-components/marketplace-app-bar"
import { Container, Grid, ListSubheader, Typography } from "@material-ui/core"
import MarketplaceNavigation from "../Components/marketplace-components/marketplace-navigation"
import { makeStyles } from '@material-ui/core/styles';
import Divider from '@material-ui/core/Divider';
import GridList from '@material-ui/core/GridList';
import Button from '@material-ui/core/Button';
import GridListTile from '@material-ui/core/GridListTile';
import GridListTileBar from '@material-ui/core/GridListTileBar';
import Box from '@material-ui/core/Box';


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

let MarketplacePage = function(){
    const classes = makeStyles()
    return(
    <div class={classes.root}>
      <MarketplaceAppBar />
      <MarketplaceNavigation className={classes.navigation} />
      <Container maxWidth="100px">
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
      </Container>
    </div>
    )

}

export default MarketplacePage;