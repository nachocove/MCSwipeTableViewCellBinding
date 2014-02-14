all:
	make -C MCSwipeTableViewCellLib
	make -C MCSwipeTableViewCellBinding

clean:
	make -C MCSwipeTableViewCellLib clean
	make -C MCSwipeTableViewCellBinding clean
