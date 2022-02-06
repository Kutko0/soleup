import axios from 'axios';
const URL = "http://localhost:5000";

export const GET_ALL_DROP_ITEMS = URL + "/api/Drops/item/all";
export const GET_ALL_DROP_USERS = URL + "/api/Drops/user/all";
export const POST_DROP_ITEM_TAKE = URL + "/api/Drops/item/take";
export const POST_DROP_USER_ENROLL = URL + "/api/Drops/user/enroll";
export const POST_DROP_ITEM_NEW = URL + "/api/Drops/item/new"
export const POST_DROP_USER_NEW = URL + "/api/Drops/user/new"
export const POST_ADMIN_LOGIN = URL + "/api/Drops/admin/login"

export async function checkToken(token) {
    axios.post(POST_DROP_USER_ENROLL + "/" + token,
      {
        headers: {
          'Access-Control-Allow-Origin': 'localhost:5000'
        }
      }
      )
      .then((response) => {
        console.debug("APIURL funkcia")
        console.debug(response.data.item)
        return true;
        //if(response.data.item.token == testToken){
        //  changeButtonState(false)
        //}
        //setTokens(response.data.item);
        //changeButtonState(true);
        //return 0;
      })
      .catch((error) => {
        console.debug(error)
      })
      return false;

}