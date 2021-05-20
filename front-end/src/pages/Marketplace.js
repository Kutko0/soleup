import MarketplaceItem from "../Components/marketplace-components/marketplace-item"
import MarketplaceAppBar from "../Components/marketplace-components/marketplace-app-bar"
import { Container, Grid, Typography } from "@material-ui/core"
import MarketplaceNavigation from "../Components/marketplace-components/marketplace-navigation"
import { makeStyles } from '@material-ui/core/styles';
import Divider from '@material-ui/core/Divider';


const useStyles = makeStyles((theme) => ({
    root: {
      backgroundColor: "grey",
    },
    navigation: {
        marginLeft: "auto",
        marginRight: "auto",
    }

}));

let MarketplacePage = function(){
    const classes = makeStyles()
    return(
    <div class={classes.root}>
      <MarketplaceAppBar />
      <MarketplaceNavigation className={classes.navigation} />
      <Divider
        variant="middle"
      ></Divider>
        <Typography>hello?</Typography>
    </div>
    )

}

export default MarketplacePage;