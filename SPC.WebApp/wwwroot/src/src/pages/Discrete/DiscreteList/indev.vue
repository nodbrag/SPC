<template>
  <!--  <div>
        <el-row class="warp">
            <el-col ::span="24" class="warp-main box_table" v-loading="loading" element-loading-text="拼命加载中">
            </el-col>
        </el-row>
        <div class="box_table">
            <TableToolBar :formData="formSearch"  @addModal="addModal(1)">
                <el-form-item slot="input">
                    <el-input
                              size="mini"
                              placeholder="批号"
                              v-model="formSearch.batchB">
                    </el-input>
                </el-form-item>
                <el-form-item slot="input">
                    <el-date-picker
                        v-model="formSearch.starttime"
                        type="date"
                        placeholder="开始时间" value-format="yyyy-MM-dd">
                    </el-date-picker>
                </el-form-item>
                <el-form-item slot="input">
                    <el-date-picker
                        v-model="formSearch.endtime"
                        type="date"
                        placeholder="结束时间">
                    </el-date-picker>
                </el-form-item>
                <div slot="addModal" class="box_add">
                    <el-button type="primary" icon="el-icon-circle-plus-outline" size="mini" @click="addModal">添加</el-button>
                </div>
            </TableToolBar>
            <el-table
                :data="tableData.filter(data => !search || data.batch.toLowerCase().includes(search.toLowerCase()))"
                :default-sort = "{prop: 'number', order: 'descending'}"
                stripe
                style="width: 100%">
                <el-table-column
                label="批次B"
                prop="batchB">
                </el-table-column>
                <el-table-column
                label="产品名称"
                prop="productName">
                </el-table-column>
                <el-table-column
                label="注塑机号"
                prop="injection">
                </el-table-column>
                <el-table-column
                label="模具号"
                prop="moldnumber">
                </el-table-column>
                <el-table-column
                label="模穴号"
                prop="mouldpointnumber">
                </el-table-column>
                <el-table-column
                label="摆件机器"
                prop="pendulumMachine">
                </el-table-column>
                <el-table-column
                label="摆件时间"
                prop="pendulumTime">
                </el-table-column>
                <el-table-column
                label="摆件数量"
                prop="pendulumNumber">
                </el-table-column>
                <el-table-column
                label="操作员"
                prop="operator">
                </el-table-column>
                <el-table-column
                label="操作">
                    <template slot-scope="scope">
                        <el-dropdown>
                            <span class="el-dropdown-link">
                                <i class="el-icon-caret-bottom el-icon--right"></i>   详细
                            </span>
                            <el-dropdown-menu slot="dropdown">
                                <el-dropdown-item><span @click="handleEdit(scope.$index, scope.row)">编辑</span></el-dropdown-item>
                                <el-dropdown-item><span  @click="handleDelete(scope.$index, scope.row)">删除</span></el-dropdown-item>
                            </el-dropdown-menu>
                        </el-dropdown>
                    </template>
                </el-table-column>
            </el-table>
            <Pagination></Pagination>
        </div>
        <addEditModal v-show="addVisible" :visible.sync="addVisible" :addOrEdit="addOrEdit" :formData="addOrEdit===1?{}:formModal" @handleModal="handleModal(arguments)" />
        <delModal v-show="delVisible" :visible.sync="delVisible" :rowId="rowId" @handleModalDel="handleModalDel(arguments)"></delModal>
    </div>-->
  <el-row class="warp">
    <el-col ::span="24" class="warp-main box_table" v-loading="loading" element-loading-text="拼命加载中">
      <!--工具条-->
      <div class="table_tool">
        <div class="box_search">
          <el-form ref="form" :model="filter">
             <el-input v-model="filter.batchNo" placeholder="批次号" @keyup.enter.native="search" size="mini"></el-input>
             <el-date-picker v-model="filter.beginDateTime" placeholder="开始时间" value-format="yyyy-MM-dd" >
             </el-date-picker>
             <el-date-picker v-model="filter.endDateTime" placeholder="结束时间" value-format="yyyy-MM-dd">
             </el-date-picker>
             <el-select v-model="filter.productId"  placeholder="请选择产品">
              <el-option
                v-for="item in productOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
            <el-button type="primary" icon="el-icon-search" size="mini" @click="searchDiscrete" >搜索</el-button>
            <el-button type="primary" icon="el-icon-circle-plus-outline" style="float: right"  size="mini" @click="showAddDialog" >添加</el-button>
          </el-form>
        </div>
      </div>
      <!--列表-->
      <el-table class="tableCss" :data="DiscreteList" highlight-current-row @selection-change="selectInfos" stripe style="width: 100%;">
        <el-table-column type="index" width="60">
        </el-table-column>
        <el-table-column prop="batchNo" label="批次号"  sortable>
        </el-table-column>
        <el-table-column prop="productName" label="产品名称" width=""  sortable>
        </el-table-column>
        <el-table-column prop="injectionEquipmentName" label="注射设备名"  sortable>
        </el-table-column>
        <el-table-column prop="swayEquipmentName" label="摆件设备名"  sortable>
        </el-table-column>
        <el-table-column prop="plasticEquipmentName" label="整形设备名"  sortable>
        </el-table-column>
        <el-table-column prop="firingEquipmentName" label="烧结设备名"  sortable>
        </el-table-column>
        <el-table-column prop="sTime" label="注射开始时间"  sortable>
        </el-table-column>
        <el-table-column prop="cavityName" label="模穴位"  sortable>
        </el-table-column>
        <el-table-column prop="matrixName" label="模具号"  sortable>
        </el-table-column>
        <el-table-column label="操作" width="150">
          <template slot-scope="scope">
            <el-button size="small" @click="jumpHtml(scope.row.batchNo)">编辑</el-button>
            <el-button type="danger" @click="delBatchNo(scope.row.batchNo)" size="small">删除</el-button>
          </template>
        </el-table-column>
      </el-table>
      <!--工具条-->
      <el-col :span="24" class="toolbar">
        <Pagination
          @handleCurrentChange="handleCurrentChange"
          @handleSizeChange="maxResultCountSelect"
          :page-size="maxResultCount"
          :page-sizes="pageSelectList"
          :total="totalCount">
        </Pagination>
      </el-col>
      <!--新增界面-->
      <el-dialog  :visible.sync ="addFormVisible"  :before-close="closeAddDialog" class="lisan">
        <div slot="title">添加离散数据</div>
        <el-form :model="addForm" label-width="160px" :rules="editFormRules" ref="addForm">
          <el-form-item label="批次编号:" size="small">
            <el-row :gutter="10"><el-col :span="15"><el-input v-model="addForm.batchNo"></el-input><div class="red">*</div></el-col></el-row>
          </el-form-item>
          <el-form-item label="产品名称:" size="small">
            <el-row :gutter="10">
              <el-col :span="15">
                <el-select v-model="addForm.productId" placeholder="请选择产品">
                  <el-option
                    v-for="item in productOptions"
                    :key="item.id"
                    :label="item.name"
                    :value="item.id">
                  </el-option>
                </el-select>
              </el-col>
            </el-row>
          </el-form-item>
          <el-row :gutter="40" style="margin-bottom:20px">
            <el-col :span="5" style="padding-right:0px">
              <el-select v-model="addForm.workProcessId1">
                <el-option
                  v-for="item in workProcess1Options"
                  :key="item.id"
                  :label="item.name"
                  :value="item.id">
                </el-option>
              </el-select>
            </el-col>
            <el-col :span="19">
              <el-row :gutter="10">
              <el-col :span="5">
                <el-select v-model="addForm.equipmentId1" placeholder="设备编号">
                  <el-option
                    v-for="item in equipmentOptions"
                    :key="item.id"
                    :label="item.name"
                    :value="item.id">
                  </el-option>
                </el-select>
              </el-col>
              <el-col :span="5"><el-date-picker v-model="addForm.beginDateTime1" placeholder="时间" value-format="yyyy-MM-dd"></el-date-picker></el-col>
              <el-col :span="5"><el-input v-model="addForm.quantity1" placeholder="数量" type="number"></el-input></el-col>
              <el-col :span="4"><el-input v-model="addForm.userDefine1" placeholder="模具编号"></el-input></el-col>
              <el-col :span="4"><el-input v-model="addForm.userDefine2" placeholder="模穴编号"></el-input></el-col></el-row></el-col>
          </el-row>
          <el-row :gutter="40" style="margin-bottom:20px">
              <el-col :span="5" style="padding-right:0px">
                <el-select v-model="addForm.workProcessId2">
                  <el-option
                    v-for="item in workProcess2Options"
                    :key="item.id"
                    :label="item.name"
                    :value="item.id">
                  </el-option>
                </el-select>
              </el-col>
              <el-col :span="19">
                <el-row :gutter="10">
                  <el-col :span="5">
                    <el-select v-model="addForm.equipmentId2" placeholder="设备编号">
                      <el-option
                        v-for="item in equipmentOptions"
                        :key="item.id"
                        :label="item.name"
                        :value="item.id">
                      </el-option>
                    </el-select>
                    </el-col>
                  <el-col :span="5"><el-date-picker v-model="addForm.beginDateTime2" placeholder="时间" value-format="yyyy-MM-dd"></el-date-picker></el-col>
                  <el-col :span="5"><el-input v-model="addForm.quantity2" placeholder="数量" type="number"></el-input></el-col>
                </el-row>
              </el-col>
            </el-row>
          <el-row :gutter="40" style="margin-bottom:20px">
              <el-col :span="5" style="padding-right:0px">
                <el-select v-model="addForm.workProcessId3">
                  <el-option
                    v-for="item in workProcess3Options"
                    :key="item.id"
                    :label="item.name"
                    :value="item.id">
                  </el-option>
                </el-select>
              </el-col>
              <el-col :span="19">
            <el-row :gutter="10">
              <el-col :span="5">
                <el-select v-model="addForm.equipmentId3" placeholder="设备编号">
                  <el-option
                    v-for="item in equipmentOptions"
                    :key="item.id"
                    :label="item.name"
                    :value="item.id">
                  </el-option>
                </el-select>
              </el-col>
              <el-col :span="5"><el-date-picker v-model="addForm.beginDateTime3" placeholder="时间" value-format="yyyy-MM-dd"></el-date-picker></el-col>
              <el-col :span="5"><el-input v-model="addForm.quantity3" placeholder="数量" type="number"></el-input></el-col></el-row></el-col>
            </el-row>
           <el-row :gutter="40" style="margin-bottom:20px">
              <el-col :span="5" style="padding-right:0px">
                <el-select v-model="addForm.workProcessId4">
                  <el-option
                    v-for="item in workProcess4Options"
                    :key="item.id"
                    :label="item.name"
                    :value="item.id">
                  </el-option>
                </el-select>
              </el-col>
              <el-col :span="19">
                <el-row :gutter="10">
                <el-col :span="5">
                  <el-select v-model="addForm.equipmentId4" placeholder="设备编号">
                    <el-option
                      v-for="item in equipmentOptions"
                      :key="item.id"
                      :label="item.name"
                      :value="item.id">
                    </el-option>
                  </el-select>
              </el-col>
              <el-col :span="5"><el-date-picker v-model="addForm.beginDateTime4" placeholder="时间" value-format="yyyy-MM-dd"></el-date-picker></el-col>
              <el-col :span="5"><el-input v-model="addForm.quantity4" placeholder="数量" type="number"></el-input></el-col></el-row></el-col>
            </el-row>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click.native="closeAddDialog">取消</el-button>
          <el-button type="primary" @click.native="addTasksList" :loading="loading">保存</el-button>
        </div>
      </el-dialog>
    </el-col>
  </el-row>
</template>
<script>
  import DiscreteView from '../../../View/DiscreteView';
  export default new DiscreteView()
</script>
<style lang="stylus" scope>
  @import '../../../common/common.stylus'
  .lisan .el-dialog__body{
    padding:30px 20px !important 
  }
  .lisan .el-input__inner,.lisan .el-select .el-input .el-select__caret{
    line-height: 32px;
    height: 32px;
  }
  .lisan .el-col-5 .el-select{
    width: 117px;
    float: right;
  }
  .lisan .el-col-5 .el-select .el-input__suffix{
    right:0
  }
  .lisan .el-col-5 .el-select .el-input--suffix .el-input__inner{
    padding-right: 20px;
  }
  .lisan .el-col-19 .el-col-5 .el-select{
    width: 100%;
  }
  .lisan .el-dialog{
    width:1000px !important;
  }
  // .el-form-item__content{
  //   margin-left: 202px !important;
  // }
</style>