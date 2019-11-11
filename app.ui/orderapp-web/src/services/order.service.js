import axios from "axios"

axios.defaults.baseURL = 'http://localhost:44367/api/'

const orderService = {
    getPostTop (num) {
      return new Promise((resolve) => {
        axios.get(`Post/Newest/${num}`)
          .then(response => {
            resolve(response.data);
          })
      })
    }
  }

  export default orderService