import BaseView, {BaseComputed, BaseMethods} from "../View/BaseView";
import TableToolBar from '@/components/TableToolBar/TableToolBar.vue'
import Pagination from '@/components/Pagination/Pagination.vue'

class EquipmentClassMethods extends  BaseMethods{

}
class EquipmentClassComputed extends  BaseComputed{

}
let view={
  methods:new EquipmentClassMethods(),
  computed:new EquipmentClassComputed()
};

export default class EquipmentClassView extends  BaseView {
  name='EquipmentClassView';
  get store() {
    return "EquipmentClassStore";
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
