import BaseView, {BaseComputed, BaseMethods} from "../View/BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'

class ProductMethods extends  BaseMethods{

}
class ProductComputed extends  BaseComputed{

}
let view={
  methods:new ProductMethods(),
  computed:new ProductComputed()
};
export default class ProductView extends  BaseView {
  name='ProductView';
  get store() {
    return "ProductStore";
  }
  constructor(){
    super(view);
  }
  mounted=function () {
    this.pageChange(1);
    this.search();
  }
  components={
    TableToolBar,
    Pagination
  }
}
