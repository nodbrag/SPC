import BaseView, {BaseComputed, BaseMethods} from "../View/BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'

class RoleMethods extends  BaseMethods{

}
class RoleComputed extends  BaseComputed{

}
let view={
  methods:new RoleMethods(),
  computed:new RoleComputed()
};

export default class RoleView extends  BaseView {
  name='RoleView';
  get store() {
    return "RoleStore";
  }
  constructor(){
    super(view);
  }
  mounted=function () {
    this.pageChange(1);
    this.search();
  };
  components={
    TableToolBar,
    Pagination
  }
}
