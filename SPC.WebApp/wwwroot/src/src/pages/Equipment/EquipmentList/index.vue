<template>
  <!--  <div>
       <div class="box_table">
           <TableToolBar :formData="formSearch"  @addModal="addModal(1)">
               <el-form-item slot="input">
                   <el-input
                       size="mini"
                       placeholder=""
                       v-model="formSearch.equipmentName">
                   </el-input>
               </el-form-item>
               <el-form-item slot="addModal" class="box_add">
                   <el-button type="primary" icon="el-icon-circle-plus-outline" size="mini" @click="addModal">添加</el-button>
               </el-form-item>
           </TableToolBar>
           <el-table
               :data="tableData.filter(data => !search || data.batch.toLowerCase().includes(search.toLowerCase()))"
               :default-sort = "{prop: 'number', order: 'descending'}"
               stripe
               style="width: 100%">
               <el-table-column
               label="编号"
               prop="equipmentID">
               </el-table-column>
               <el-table-column
               label="设备编号"
               prop="equipmentCode">
               </el-table-column>
               <el-table-column
               label="设备名称"
               prop="equipmentName">
               </el-table-column>
               <el-table-column
               label="设备类型"
               prop="equipmentType">
               </el-table-column>
               <el-table-column
               label="设备规格"
               prop="equipmentSpec">
               </el-table-column>
               <el-table-column
               label="投产时间"
               prop="productionDate">
               </el-table-column>
               <el-table-column
               label="生产厂商"
               prop="manufacturer">
               </el-table-column>
               <el-table-column
               label="生命周期"
               prop="lifeCircleYear">
               </el-table-column>
               <el-table-column
               label="描述"
               prop="memo">
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
    <el-col :span="24" class="warp-main box_table" v-loading="loading" element-loading-text="拼命加载中">
      <!--工具条-->
      <div class="table_tool">
        <div class="box_search">
          <el-form ref="form" :model="filter">
            <el-input v-model="filter.equipmentKeyword" placeholder="设备名或编号" @keyup.enter.native="search" size="mini"></el-input>
            <el-button type="primary" icon="el-icon-search" size="mini" @click="search" >搜索</el-button>
            <el-button type="primary" icon="el-icon-circle-plus-outline" style="float: right"  size="mini" @click="showAddDialog" >添加</el-button>
          </el-form>
        </div>
      </div>
      <!--列表-->
      <el-table class="tableCss" :data="datalist" highlight-current-row @selection-change="selectInfos" stripe
                style="width: 100%;">
        <el-table-column type="index" width="60">
        </el-table-column>
        <el-table-column prop="equipmentCode" label="设备编号"  sortable>
        </el-table-column>
        <el-table-column prop="equipmentName" label="设备名称" width="180"  sortable>
        </el-table-column>
        <el-table-column prop="equipmentClassName" label="设备分类"  sortable>
        </el-table-column>
        <el-table-column prop="equipmentType" label="设备类型"  sortable>
        </el-table-column>
        <el-table-column prop="equipmentSpec" label="设备规格"  sortable>
        </el-table-column>
        <el-table-column prop="productionDate" label="投产时间"  sortable>
        </el-table-column>
        <el-table-column prop="manufacturer" label="生产厂商"  sortable>
        </el-table-column>
        <el-table-column prop="lifeCircleYear" label="生命周期"  sortable>
        </el-table-column>
        <el-table-column prop="memo" label="备注"  sortable>
        </el-table-column>
        <el-table-column label="操作" width="180">
          <template slot-scope="scope">
            <el-button size="small" @click="showEditDialog(scope.row)">编辑</el-button>
            <el-button type="danger" @click="del(scope.row.equipmentId)" size="small">删除</el-button>
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
      <el-dialog  :visible.sync ="addFormVisible"  :before-close="closeAddDialog">
        <div slot="title">添加设备</div>
        <el-form :model="addForm" label-width="130px" :rules="editFormRules" ref="addForm">
          <el-form-item label="设备编号:" prop="equipmentCode">
            <el-input v-model="addForm.equipmentCode" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="设备名称:" prop="equipmentName">
            <el-input v-model="addForm.equipmentName" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="设备分类:" prop="equipmentClassId">
            <el-select v-model="addForm.equipmentClassId"  placeholder="请选择">
              <el-option
                v-for="item in equipmentClassOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="设备类型:" prop="equipmentType">
            <el-select v-model="addForm.equipmentType"  placeholder="请选择">
              <el-option
                v-for="item in equipmentTypeOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="设备规格:" prop="equipmentSpec">
            <el-input v-model="addForm.equipmentSpec" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="投产时间:"  prop="productionDate" size="small">
            <el-date-picker v-model="addForm.productionDate" value-format="yyyy-MM-dd">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="生产厂商:" prop="equipmentSpec">
            <el-input v-model="addForm.manufacturer" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="生命周期:" prop="lifeCircleYear">
            <el-input type="number" v-model="addForm.lifeCircleYear" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="备注:" prop="memo">
            <el-input type="textarea" v-model="addForm.memo" auto-complete="off"></el-input>
          </el-form-item>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click.native="closeAddDialog">取消</el-button>
          <el-button type="primary" @click.native="add" :loading="loading">保存</el-button>
        </div>
      </el-dialog>

      <el-dialog  :visible.sync ="editFormVisible"   :before-close="closeEditDialog">
        <div slot="title">编辑设备</div>
        <el-form :model="editForm" label-width="130px" :rules="editFormRules" ref="editForm">
          <el-form-item label="设备编号:" prop="equipmentCode">
            <el-input v-model="editForm.equipmentCode" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="设备名称:" prop="equipmentName">
            <el-input v-model="editForm.equipmentName" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="设备分类:" prop="equipmentClassId">
            <el-select v-model="editForm.equipmentClassId"  placeholder="请选择">
              <el-option
                v-for="item in equipmentClassOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="设备类型:" prop="equipmentType">
            <el-select v-model="editForm.equipmentType"  placeholder="请选择">
              <el-option
                v-for="item in equipmentTypeOptions"
                :key="item.name"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="设备规格:" prop="equipmentSpec">
            <el-input v-model="editForm.equipmentSpec" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="投产时间:"  prop="productionDate" size="small">
            <el-date-picker v-model="editForm.productionDate" value-format="yyyy-MM-dd">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="生产厂商:" prop="equipmentSpec">
            <el-input v-model="editForm.manufacturer" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="生命周期:" prop="lifeCircleYear">
            <el-input type="number" v-model="editForm.lifeCircleYear" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="备注:" prop="memo">
            <el-input type="textarea" v-model="editForm.memo" auto-complete="off"></el-input>
          </el-form-item>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click.native="closeEditDialog">取消</el-button>
          <el-button type="primary" @click.native="edit">保存</el-button>
        </div>
      </el-dialog>
    </el-col>
  </el-row>
</template>
<script>
  import EquipmentView from '../../../View/EquipmentView';
  export default new EquipmentView()
</script>
<style lang="stylus" scope>
  @import '../../../common/common.stylus'
</style>
