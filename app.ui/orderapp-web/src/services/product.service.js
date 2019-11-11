import axios from "axios"

axios.defaults.baseURL = 'http://localhost:5000/api/'

const productService = {
    getAllProduct () {
      return new Promise((resolve) => {
        axios.get(`Product`)
          .then(response => {
            resolve(response.data);
          })
      })
    }
  }

  export default productService