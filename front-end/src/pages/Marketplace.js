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
import Footer from "../Components/marketplace-components/footer";
import UserPage from "../Components/marketplace-components/user-page";
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
              <Market/>
            </Route>
          </Switch>
        </Container>
    </Router>
    <Footer></Footer>
    </div>
    )

}

export default MarketplacePage;