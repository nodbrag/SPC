import BaseView, {BaseComputed, BaseMethods} from "../View/BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'

class DefectItemMethods extends  BaseMethods{

}
class DefectItemComputed extends  BaseComputed{

}
let view={
  methods:new DefectItemMethods(),
  computed:new DefectItemComputed()
};

export default class DefectItemView extends  BaseView {
  name='DefectItemView';
  get store() {
    return "DefectItemStore";
  }
  constructor(){
    super(view);
  }
  mounted=function () {
    this.search();
  }
  components={
    TableToolBar,
    Pagination
  }
}
