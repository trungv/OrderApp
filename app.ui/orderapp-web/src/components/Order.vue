<template>
  <div class="container py-5 order-form">
    <div class="row">
      <div class="col-md-10 mx-auto">
        <form>
          <div class="form-group row">
            <div class="col-sm-6">
              <label for="inputFirstname">Status:</label>
              <label for="inputFirstname">{{newOrder.Status}}</label>
            </div>
            <div class="col-sm-6">
              <label for="inputFirstname">Order Date:</label>
              <label for="inputFirstname">{{newOrder.OrderDate}}</label>
            </div>
          </div>
          <div class="form-group row">
            <div class="col-sm-12">
              <label for="inputFirstname">Customer Infomation:</label>
            </div>
          </div>
          <div class="form-group row">
            <div class="col-sm-6">
              <label for="inputFullName">Full name</label>
              <input type="text" v-model="customer.Name" class="form-control" id="inputFullName" placeholder="Full name" />
            </div>
            <div class="col-sm-6">
              <label for="inputEmail">Email</label>
              <input
                type="text"
                class="form-control"
                id="inputEmail"
                placeholder="example@email.com"
                v-model="customer.Email"
              />
            </div>
          </div>
          <div class="form-group row">
            <div class="col-sm-6">
              <label for="inputAddress">Address</label>
              <textarea
                class="form-control rounded-0"
                id="inputAddress"
                rows="3"
                placeholder="01 Le Duan Street"
                v-model="customer.Address"
              ></textarea>
            </div>
            <div class="col-sm-6">
              <label for="inputAddressLine2">Phone</label>
              <input type="text" class="form-control" id="inputPhone" placeholder="0123-456-789" v-model="customer.Phone"/>
              <label for="inputAddressLine2">Country</label>
              <select class="form-control" id="exampleFormControlSelect1" v-model="customer.Country">
                <option>Viet Nam</option>
                <option>Lao</option>
              </select>
            </div>
          </div>
          <div class="form-group row">
            <div class="col-sm-12">
              <label for="inputFirstname">Order Detail:</label>
            </div>
          </div>
          <div class="form-group row">
            <div class="col-sm-12">
              <table class="table">
                <thead>
                  <tr>
                    <th scope="col">#</th>
                    <th scope="col">First</th>
                    <th scope="col">Last</th>
                    <th scope="col">Handle</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <th scope="row">1</th>
                    <td>Mark</td>
                    <td>Otto</td>
                    <td>@mdo</td>
                  </tr>
                  <tr>
                    <th scope="row">2</th>
                    <td>Jacob</td>
                    <td>Thornton</td>
                    <td>@fat</td>
                  </tr>
                  <tr>
                    <th scope="row">3</th>
                    <td>Larry</td>
                    <td>the Bird</td>
                    <td>@twitter</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
          <button type="button" v-on:click="onSubmit()" class="btn btn-primary px-4 float-right">Save</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import productService from "../services/product.service.js"
export default {
  name: "PostManage",
  data () {
    return {
      newOrder: {
        Status:"New",
        OrderDate:"10/10/2010"
      },
      customer: {},
      products: []
    }
  },
  methods: {
    onSubmit () {
      console.log(this.newOrder);
      console.log(this.customer);
      console.log(this.products);
      
      productService.getAllProduct().then(data => {
        this.posts = data
        console.log(data)
      })
    },
  },
  created(){
    //this.loadAllPost();
    //this.loadCategories();
  }
};
</script>
<style scoped lang="scss">
.order-form {
  text-align: left;
}
</style>