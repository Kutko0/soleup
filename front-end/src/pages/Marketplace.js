import MarketplaceAppBar from "../Components/marketplace-components/marketplace-app-bar"
import { Container} from "@material-ui/core"
import MarketplaceNavigation from "../Components/marketplace-components/marketplace-navigation"
import { makeStyles } from '@material-ui/core/styles';
import  Market  from '../Components/marketplace-components/market-store'
import {BrowserRouter as Router, Route, Switch} from 'react-router-dom';
import Home from "../Components/marketplace-components/home";
import News from "../Components/marketplace-components/news";
import Auctions from "../Components/marketplace-components/auctions";
import FcfsRaffles from "../Components/marketplace-components/fcfs-raffles";
const useStyles = makeStyles((theme) => ({
    root: {
      backgroundColor: "grey",
    },
    navigation: {
        marginLeft: "auto",
        marginRight: "auto",
    },
    centerButton: {
      height: "100px"
    },
    buttonStyle: {
      color: "#212121"
    }

}));

let MarketplacePage = function(){
    const classes = makeStyles()
    return(
    <div class={classes.root}>
      <Router>
        <MarketplaceNavigation className={classes.navigation} />
        <Container maxWidth="100px">
          <Switch>
            <Route exact path="/">
              <Home/>
            </Route>
            <Route path="/market">
              <Market/>
            </Route>
            <Route path="/news">
              <News />
            </Route>
            <Route path="/auctions">
              <Auctions />
            </Route>
            <Route path="/fcfsRaffles">
              <FcfsRaffles />
            </Route>
          </Switch>
        </Container>
    </Router>
    </div>
    )

}

export default MarketplacePage;